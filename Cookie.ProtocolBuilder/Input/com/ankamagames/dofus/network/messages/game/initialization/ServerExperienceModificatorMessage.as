package com.ankamagames.dofus.network.messages.game.initialization
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ServerExperienceModificatorMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6237;
       
      
      private var _isInitialized:Boolean = false;
      
      public var experiencePercent:uint = 0;
      
      public function ServerExperienceModificatorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6237;
      }
      
      public function initServerExperienceModificatorMessage(param1:uint = 0) : ServerExperienceModificatorMessage
      {
         this.experiencePercent = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.experiencePercent = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ServerExperienceModificatorMessage(param1);
      }
      
      public function serializeAs_ServerExperienceModificatorMessage(param1:ICustomDataOutput) : void
      {
         if(this.experiencePercent < 0)
         {
            throw new Error("Forbidden value (" + this.experiencePercent + ") on element experiencePercent.");
         }
         param1.writeVarShort(this.experiencePercent);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ServerExperienceModificatorMessage(param1);
      }
      
      public function deserializeAs_ServerExperienceModificatorMessage(param1:ICustomDataInput) : void
      {
         this._experiencePercentFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ServerExperienceModificatorMessage(param1);
      }
      
      public function deserializeAsyncAs_ServerExperienceModificatorMessage(param1:FuncTree) : void
      {
         param1.addChild(this._experiencePercentFunc);
      }
      
      private function _experiencePercentFunc(param1:ICustomDataInput) : void
      {
         this.experiencePercent = param1.readVarUhShort();
         if(this.experiencePercent < 0)
         {
            throw new Error("Forbidden value (" + this.experiencePercent + ") on element of ServerExperienceModificatorMessage.experiencePercent.");
         }
      }
   }
}

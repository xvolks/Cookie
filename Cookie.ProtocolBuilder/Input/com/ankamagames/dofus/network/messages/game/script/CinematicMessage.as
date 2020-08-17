package com.ankamagames.dofus.network.messages.game.script
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CinematicMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6053;
       
      
      private var _isInitialized:Boolean = false;
      
      public var cinematicId:uint = 0;
      
      public function CinematicMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6053;
      }
      
      public function initCinematicMessage(param1:uint = 0) : CinematicMessage
      {
         this.cinematicId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.cinematicId = 0;
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
         this.serializeAs_CinematicMessage(param1);
      }
      
      public function serializeAs_CinematicMessage(param1:ICustomDataOutput) : void
      {
         if(this.cinematicId < 0)
         {
            throw new Error("Forbidden value (" + this.cinematicId + ") on element cinematicId.");
         }
         param1.writeVarShort(this.cinematicId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CinematicMessage(param1);
      }
      
      public function deserializeAs_CinematicMessage(param1:ICustomDataInput) : void
      {
         this._cinematicIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CinematicMessage(param1);
      }
      
      public function deserializeAsyncAs_CinematicMessage(param1:FuncTree) : void
      {
         param1.addChild(this._cinematicIdFunc);
      }
      
      private function _cinematicIdFunc(param1:ICustomDataInput) : void
      {
         this.cinematicId = param1.readVarUhShort();
         if(this.cinematicId < 0)
         {
            throw new Error("Forbidden value (" + this.cinematicId + ") on element of CinematicMessage.cinematicId.");
         }
      }
   }
}

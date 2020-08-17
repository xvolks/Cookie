package com.ankamagames.dofus.network.messages.game.achievement
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AchievementFinishedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6208;
       
      
      private var _isInitialized:Boolean = false;
      
      public var id:uint = 0;
      
      public var finishedlevel:uint = 0;
      
      public function AchievementFinishedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6208;
      }
      
      public function initAchievementFinishedMessage(param1:uint = 0, param2:uint = 0) : AchievementFinishedMessage
      {
         this.id = param1;
         this.finishedlevel = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.id = 0;
         this.finishedlevel = 0;
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
         this.serializeAs_AchievementFinishedMessage(param1);
      }
      
      public function serializeAs_AchievementFinishedMessage(param1:ICustomDataOutput) : void
      {
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeVarShort(this.id);
         if(this.finishedlevel < 0 || this.finishedlevel > 206)
         {
            throw new Error("Forbidden value (" + this.finishedlevel + ") on element finishedlevel.");
         }
         param1.writeByte(this.finishedlevel);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AchievementFinishedMessage(param1);
      }
      
      public function deserializeAs_AchievementFinishedMessage(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this._finishedlevelFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AchievementFinishedMessage(param1);
      }
      
      public function deserializeAsyncAs_AchievementFinishedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         param1.addChild(this._finishedlevelFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readVarUhShort();
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of AchievementFinishedMessage.id.");
         }
      }
      
      private function _finishedlevelFunc(param1:ICustomDataInput) : void
      {
         this.finishedlevel = param1.readUnsignedByte();
         if(this.finishedlevel < 0 || this.finishedlevel > 206)
         {
            throw new Error("Forbidden value (" + this.finishedlevel + ") on element of AchievementFinishedMessage.finishedlevel.");
         }
      }
   }
}

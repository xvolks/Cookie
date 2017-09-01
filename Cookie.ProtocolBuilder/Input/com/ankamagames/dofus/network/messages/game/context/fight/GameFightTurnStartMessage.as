package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightTurnStartMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 714;
       
      
      private var _isInitialized:Boolean = false;
      
      public var id:Number = 0;
      
      public var waitTime:uint = 0;
      
      public function GameFightTurnStartMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 714;
      }
      
      public function initGameFightTurnStartMessage(param1:Number = 0, param2:uint = 0) : GameFightTurnStartMessage
      {
         this.id = param1;
         this.waitTime = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.id = 0;
         this.waitTime = 0;
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
         this.serializeAs_GameFightTurnStartMessage(param1);
      }
      
      public function serializeAs_GameFightTurnStartMessage(param1:ICustomDataOutput) : void
      {
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeDouble(this.id);
         if(this.waitTime < 0)
         {
            throw new Error("Forbidden value (" + this.waitTime + ") on element waitTime.");
         }
         param1.writeVarInt(this.waitTime);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightTurnStartMessage(param1);
      }
      
      public function deserializeAs_GameFightTurnStartMessage(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this._waitTimeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightTurnStartMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightTurnStartMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         param1.addChild(this._waitTimeFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readDouble();
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of GameFightTurnStartMessage.id.");
         }
      }
      
      private function _waitTimeFunc(param1:ICustomDataInput) : void
      {
         this.waitTime = param1.readVarUhInt();
         if(this.waitTime < 0)
         {
            throw new Error("Forbidden value (" + this.waitTime + ") on element of GameFightTurnStartMessage.waitTime.");
         }
      }
   }
}

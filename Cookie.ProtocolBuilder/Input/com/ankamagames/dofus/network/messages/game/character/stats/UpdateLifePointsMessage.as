package com.ankamagames.dofus.network.messages.game.character.stats
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class UpdateLifePointsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5658;
       
      
      private var _isInitialized:Boolean = false;
      
      public var lifePoints:uint = 0;
      
      public var maxLifePoints:uint = 0;
      
      public function UpdateLifePointsMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5658;
      }
      
      public function initUpdateLifePointsMessage(param1:uint = 0, param2:uint = 0) : UpdateLifePointsMessage
      {
         this.lifePoints = param1;
         this.maxLifePoints = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.lifePoints = 0;
         this.maxLifePoints = 0;
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
         this.serializeAs_UpdateLifePointsMessage(param1);
      }
      
      public function serializeAs_UpdateLifePointsMessage(param1:ICustomDataOutput) : void
      {
         if(this.lifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.lifePoints + ") on element lifePoints.");
         }
         param1.writeVarInt(this.lifePoints);
         if(this.maxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.maxLifePoints + ") on element maxLifePoints.");
         }
         param1.writeVarInt(this.maxLifePoints);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_UpdateLifePointsMessage(param1);
      }
      
      public function deserializeAs_UpdateLifePointsMessage(param1:ICustomDataInput) : void
      {
         this._lifePointsFunc(param1);
         this._maxLifePointsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_UpdateLifePointsMessage(param1);
      }
      
      public function deserializeAsyncAs_UpdateLifePointsMessage(param1:FuncTree) : void
      {
         param1.addChild(this._lifePointsFunc);
         param1.addChild(this._maxLifePointsFunc);
      }
      
      private function _lifePointsFunc(param1:ICustomDataInput) : void
      {
         this.lifePoints = param1.readVarUhInt();
         if(this.lifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.lifePoints + ") on element of UpdateLifePointsMessage.lifePoints.");
         }
      }
      
      private function _maxLifePointsFunc(param1:ICustomDataInput) : void
      {
         this.maxLifePoints = param1.readVarUhInt();
         if(this.maxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.maxLifePoints + ") on element of UpdateLifePointsMessage.maxLifePoints.");
         }
      }
   }
}

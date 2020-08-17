package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.dofus.network.types.game.context.fight.GameFightFighterInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightSummonMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5825;
       
      
      private var _isInitialized:Boolean = false;
      
      public var summons:Vector.<GameFightFighterInformations>;
      
      private var _summonstree:FuncTree;
      
      public function GameActionFightSummonMessage()
      {
         this.summons = new Vector.<GameFightFighterInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5825;
      }
      
      public function initGameActionFightSummonMessage(param1:uint = 0, param2:Number = 0, param3:Vector.<GameFightFighterInformations> = null) : GameActionFightSummonMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.summons = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.summons = new Vector.<GameFightFighterInformations>();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameActionFightSummonMessage(param1);
      }
      
      public function serializeAs_GameActionFightSummonMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         param1.writeShort(this.summons.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.summons.length)
         {
            param1.writeShort((this.summons[_loc2_] as GameFightFighterInformations).getTypeId());
            (this.summons[_loc2_] as GameFightFighterInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightSummonMessage(param1);
      }
      
      public function deserializeAs_GameActionFightSummonMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:GameFightFighterInformations = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(GameFightFighterInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.summons.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightSummonMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightSummonMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._summonstree = param1.addChild(this._summonstreeFunc);
      }
      
      private function _summonstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._summonstree.addChild(this._summonsFunc);
            _loc3_++;
         }
      }
      
      private function _summonsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:GameFightFighterInformations = ProtocolTypeManager.getInstance(GameFightFighterInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.summons.push(_loc3_);
      }
   }
}

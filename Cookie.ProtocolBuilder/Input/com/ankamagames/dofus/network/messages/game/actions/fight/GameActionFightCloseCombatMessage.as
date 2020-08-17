package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightCloseCombatMessage extends AbstractGameActionFightTargetedAbilityMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6116;
       
      
      private var _isInitialized:Boolean = false;
      
      public var weaponGenericId:uint = 0;
      
      public function GameActionFightCloseCombatMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6116;
      }
      
      public function initGameActionFightCloseCombatMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:int = 0, param5:uint = 1, param6:Boolean = false, param7:Boolean = false, param8:uint = 0) : GameActionFightCloseCombatMessage
      {
         super.initAbstractGameActionFightTargetedAbilityMessage(param1,param2,param3,param4,param5,param6,param7);
         this.weaponGenericId = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.weaponGenericId = 0;
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
         this.serializeAs_GameActionFightCloseCombatMessage(param1);
      }
      
      public function serializeAs_GameActionFightCloseCombatMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionFightTargetedAbilityMessage(param1);
         if(this.weaponGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.weaponGenericId + ") on element weaponGenericId.");
         }
         param1.writeVarShort(this.weaponGenericId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightCloseCombatMessage(param1);
      }
      
      public function deserializeAs_GameActionFightCloseCombatMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._weaponGenericIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightCloseCombatMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightCloseCombatMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._weaponGenericIdFunc);
      }
      
      private function _weaponGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.weaponGenericId = param1.readVarUhShort();
         if(this.weaponGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.weaponGenericId + ") on element of GameActionFightCloseCombatMessage.weaponGenericId.");
         }
      }
   }
}

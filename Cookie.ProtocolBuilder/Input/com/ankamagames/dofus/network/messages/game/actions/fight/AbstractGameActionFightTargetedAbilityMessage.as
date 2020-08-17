package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AbstractGameActionFightTargetedAbilityMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6118;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var destinationCellId:int = 0;
      
      public var critical:uint = 1;
      
      public var silentCast:Boolean = false;
      
      public var verboseCast:Boolean = false;
      
      public function AbstractGameActionFightTargetedAbilityMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6118;
      }
      
      public function initAbstractGameActionFightTargetedAbilityMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:int = 0, param5:uint = 1, param6:Boolean = false, param7:Boolean = false) : AbstractGameActionFightTargetedAbilityMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.targetId = param3;
         this.destinationCellId = param4;
         this.critical = param5;
         this.silentCast = param6;
         this.verboseCast = param7;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.targetId = 0;
         this.destinationCellId = 0;
         this.critical = 1;
         this.silentCast = false;
         this.verboseCast = false;
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
         this.serializeAs_AbstractGameActionFightTargetedAbilityMessage(param1);
      }
      
      public function serializeAs_AbstractGameActionFightTargetedAbilityMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.silentCast);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.verboseCast);
         param1.writeByte(_loc2_);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.destinationCellId < -1 || this.destinationCellId > 559)
         {
            throw new Error("Forbidden value (" + this.destinationCellId + ") on element destinationCellId.");
         }
         param1.writeShort(this.destinationCellId);
         param1.writeByte(this.critical);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractGameActionFightTargetedAbilityMessage(param1);
      }
      
      public function deserializeAs_AbstractGameActionFightTargetedAbilityMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.deserializeByteBoxes(param1);
         this._targetIdFunc(param1);
         this._destinationCellIdFunc(param1);
         this._criticalFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractGameActionFightTargetedAbilityMessage(param1);
      }
      
      public function deserializeAsyncAs_AbstractGameActionFightTargetedAbilityMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._destinationCellIdFunc);
         param1.addChild(this._criticalFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.silentCast = BooleanByteWrapper.getFlag(_loc2_,0);
         this.verboseCast = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of AbstractGameActionFightTargetedAbilityMessage.targetId.");
         }
      }
      
      private function _destinationCellIdFunc(param1:ICustomDataInput) : void
      {
         this.destinationCellId = param1.readShort();
         if(this.destinationCellId < -1 || this.destinationCellId > 559)
         {
            throw new Error("Forbidden value (" + this.destinationCellId + ") on element of AbstractGameActionFightTargetedAbilityMessage.destinationCellId.");
         }
      }
      
      private function _criticalFunc(param1:ICustomDataInput) : void
      {
         this.critical = param1.readByte();
         if(this.critical < 0)
         {
            throw new Error("Forbidden value (" + this.critical + ") on element of AbstractGameActionFightTargetedAbilityMessage.critical.");
         }
      }
   }
}
